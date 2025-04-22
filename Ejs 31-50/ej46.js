class BlueskySocial {
    constructor() {
      this.users = new Map(); // key: userId, value: User object
      this.posts = new Map(); // key: postId, value: Post object
    }
  
    // Registrar un nuevo usuario
    registerUser(userId, name) {
      if (this.users.has(userId)) {
        throw new Error('El ID de usuario ya está en uso');
      }
      
      const user = {
        userId,
        name,
        following: new Set(),
        posts: new Set(),
        likes: new Set()
      };
      
      this.users.set(userId, user);
      return user;
    }
  
    // Un usuario sigue a otro
    followUser(followerId, followeeId) {
      const follower = this.users.get(followerId);
      const followee = this.users.get(followeeId);
      
      if (!follower || !followee) {
        throw new Error('Usuario no encontrado');
      }
      
      if (followerId === followeeId) {
        throw new Error('No puedes seguirte a ti mismo');
      }
      
      follower.following.add(followeeId);
    }
  
    // Un usuario deja de seguir a otro
    unfollowUser(followerId, followeeId) {
      const follower = this.users.get(followerId);
      
      if (!follower) {
        throw new Error('Usuario no encontrado');
      }
      
      follower.following.delete(followeeId);
    }
  
    // Crear un nuevo post
    createPost(userId, postId, text) {
      if (text.length > 200) {
        throw new Error('El post no puede tener más de 200 caracteres');
      }
      
      const user = this.users.get(userId);
      if (!user) {
        throw new Error('Usuario no encontrado');
      }
      
      if (this.posts.has(postId)) {
        throw new Error('El ID del post ya está en uso');
      }
      
      const post = {
        postId,
        userId,
        text,
        createdAt: new Date(),
        likes: new Set()
      };
      
      this.posts.set(postId, post);
      user.posts.add(postId);
      
      return post;
    }
  
    // Eliminar un post
    deletePost(userId, postId) {
      const post = this.posts.get(postId);
      if (!post) {
        throw new Error('Post no encontrado');
      }
      
      if (post.userId !== userId) {
        throw new Error('No puedes eliminar posts de otros usuarios');
      }
      
      const user = this.users.get(userId);
      user.posts.delete(postId);
      this.posts.delete(postId);
      
      // Eliminar likes de otros usuarios
      for (const [id, u] of this.users) {
        if (u.likes.has(postId)) {
          u.likes.delete(postId);
        }
      }
    }
  
    // Dar like a un post
    likePost(userId, postId) {
      const user = this.users.get(userId);
      const post = this.posts.get(postId);
      
      if (!user || !post) {
        throw new Error('Usuario o post no encontrado');
      }
      
      if (user.likes.has(postId)) {
        throw new Error('Ya has dado like a este post');
      }
      
      user.likes.add(postId);
      post.likes.add(userId);
    }
  
    // Quitar like de un post
    unlikePost(userId, postId) {
      const user = this.users.get(userId);
      const post = this.posts.get(postId);
      
      if (!user || !post) {
        throw new Error('Usuario o post no encontrado');
      }
      
      if (!user.likes.has(postId)) {
        throw new Error('No has dado like a este post');
      }
      
      user.likes.delete(postId);
      post.likes.delete(userId);
    }
  
    // Obtener feed personal (posts del usuario)
    getUserFeed(userId) {
      const user = this.users.get(userId);
      if (!user) {
        throw new Error('Usuario no encontrado');
      }
      
      const userPosts = Array.from(user.posts)
        .map(postId => this.posts.get(postId))
        .filter(post => post !== undefined);
      
      return this._sortAndLimitPosts(userPosts);
    }
  
    // Obtener feed de seguidos (posts de usuarios seguidos)
    getFollowingFeed(userId) {
      const user = this.users.get(userId);
      if (!user) {
        throw new Error('Usuario no encontrado');
      }
      
      const followingPosts = [];
      
      for (const followeeId of user.following) {
        const followee = this.users.get(followeeId);
        if (followee) {
          for (const postId of followee.posts) {
            const post = this.posts.get(postId);
            if (post) {
              followingPosts.push(post);
            }
          }
        }
      }
      
      return this._sortAndLimitPosts(followingPosts);
    }
  
    // Método auxiliar para ordenar y limitar posts
    _sortAndLimitPosts(posts) {
      return posts
        .sort((a, b) => b.createdAt - a.createdAt) // Más reciente primero
        .slice(0, 10) // Limitar a 10 posts
        .map(post => this._formatPost(post));
    }
  
    // Formatear post para visualización
    _formatPost(post) {
      const user = this.users.get(post.userId);
      return {
        postId: post.postId,
        userId: post.userId,
        userName: user ? user.name : '[Usuario eliminado]',
        text: post.text,
        createdAt: post.createdAt,
        likes: post.likes.size
      };
    }
  }
  
  // Ejemplo de uso
  const socialNetwork = new BlueskySocial();
  
  // Registrar usuarios
  socialNetwork.registerUser('user1', 'Alice');
  socialNetwork.registerUser('user2', 'Bob');
  socialNetwork.registerUser('user3', 'Charlie');
  
  // Seguir usuarios
  socialNetwork.followUser('user1', 'user2');
  socialNetwork.followUser('user1', 'user3');
  
  // Crear posts
  socialNetwork.createPost('user1', 'post1', 'Hola mundo!');
  socialNetwork.createPost('user2', 'post2', 'Mi primer post en Bluesky');
  socialNetwork.createPost('user3', 'post3', 'Probando esta red social descentralizada');
  
  // Dar likes
  socialNetwork.likePost('user2', 'post1');
  socialNetwork.likePost('user3', 'post1');
  
  // Obtener feeds
  console.log("Feed personal de Alice:");
  console.log(socialNetwork.getUserFeed('user1'));
  
  console.log("\nFeed de seguidos de Alice:");
  console.log(socialNetwork.getFollowingFeed('user1'));