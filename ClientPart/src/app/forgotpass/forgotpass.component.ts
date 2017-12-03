import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-forgotpass',
    templateUrl: './forgotpass.component.html',
    styleUrls: ['./forgotpass.component.css']
})
export class ForgotpassComponent implements OnInit {
    question: string;
    checkAns: string;
    answer: number;
    email: string;
    password: string;
    show: Boolean = false;
    isNotValid: Boolean = true;
    constructor(private router: Router) { }

    ngOnInit() {
        let a: number;
        let b: number;
        a = getRandomInt(1, 1000);
        b = getRandomInt((a + 1), 1000);
        this.question = a.toString() + '+' + b.toString();
        this.answer = a + b;
    }

    valuechange() {
        if (this.checkAns === this.answer.toString()) {
            this.isNotValid = false;
        } else {
            this.isNotValid = true;
        }
    }

    reload() {
        let a: number;
        let b: number;
        a = getRandomInt(1, 1000);
        b = getRandomInt((a + 1), 1000);
        this.question = a.toString() + '+' + b.toString();
        this.answer = a + b;
        this.checkAns = null;
        this.isNotValid = true;
    }

    confirm() {
        this.show = true;

        const arrKey: string[] = [];
        // tslint:disable-next-line:forin
        for (const key in localStorage) {
            arrKey.push(key);
        }

        for (let i = 0; i < localStorage.length; i++) {

            if (localStorage.getItem(arrKey[i]) != null) {

                const data = JSON.parse(localStorage.getItem(arrKey[i]));

                if ((data.email === this.email)) {
                    this.password = data.pass;
                }
            }
        }
    }
    hide() {
        this.show = false;
    }
    cancel() {
        this.router.navigate(['./login']);
    }
}

function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}
