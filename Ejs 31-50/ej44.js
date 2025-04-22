const readline = require('readline');

class Countdown {
    constructor() {
        this.rl = readline.createInterface({
            input: process.stdin,
            output: process.stdout
        });
    }

    async start() {
        console.log("¡El 12 de noviembre lanzo mouredev pro!");
        console.log("El campus de la comunidad para estudiar programación de una manera diferente: https://mouredev.pro\n");
        
        const targetDate = await this.getTargetDate();
        this.startCountdown(targetDate);
    }

    async getTargetDate() {
        const questions = [
            "Enter the year (YYYY): ",
            "Enter the month (1-12): ",
            "Enter the day (1-31): ",
            "Enter the hour (0-23): ",
            "Enter the minute (0-59): ",
            "Enter the second (0-59): "
        ];
        
        const answers = [];
        
        for (const question of questions) {
            const answer = await new Promise(resolve => {
                this.rl.question(question, resolve);
            });
            answers.push(parseInt(answer));
        }
        
        this.rl.close();
        
        const [year, month, day, hour, minute, second] = answers;
        return new Date(year, month - 1, day, hour, minute, second);
    }

    startCountdown(targetDate) {
        const countdownInterval = setInterval(() => {
            const now = new Date();
            const diff = targetDate - now;

            if (diff <= 0) {
                clearInterval(countdownInterval);
                this.clearConsole();
                console.log("¡La cuenta atrás ha finalizado! ¡Es hora de mouredev pro!");
                return;
            }

            const days = Math.floor(diff / (1000 * 60 * 60 * 24));
            const hours = Math.floor((diff % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
            const minutes = Math.floor((diff % (1000 * 60 * 60)) / (1000 * 60));
            const seconds = Math.floor((diff % (1000 * 60)) / 1000);

            this.clearConsole();
            console.log(`Countdown to mouredev pro launch:\n`);
            console.log(`${days} days, ${hours} hours, ${minutes} minutes, ${seconds} seconds remaining`);
        }, 1000);
    }

    clearConsole() {
        process.stdout.write('\x1B[2J\x1B[0f');
    }
}

// Start the countdown
const countdown = new Countdown();
countdown.start();