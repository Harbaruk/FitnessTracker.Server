import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Http, Headers } from '@angular/http';

@Component({
    selector: 'app-registration',
    templateUrl: './registration.component.html',
    styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

    firstname: string;
    lastname: string;
    email: string;
    birthday: string;
    age: number;
    sex: number;
    weight: number;
    height: number;
    sex_flag: Boolean = false;
    password: string;
    id: any = 0;

    days: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31];
    months: any[] = [{ id: 1, name: 'January' },
    { id: 2, name: 'February' },
    { id: 3, name: 'March' },
    { id: 4, name: 'April' },
    { id: 5, name: 'May' },
    { id: 6, name: 'June' },
    { id: 7, name: 'July' },
    { id: 8, name: 'August' },
    { id: 9, name: 'September' },
    { id: 10, name: 'October' },
    { id: 11, name: 'November' },
    { id: 12, name: 'December' }
    ];
    years: number[];

    day: number;
    month: string;
    year: number;

    d: Date = new Date();

    constructor(private router: Router, private _httpService: Http) { }

    ngOnInit() {
        this.firstname = '';
        this.lastname = '';
        this.email = '';
        this.birthday = null;
        this.password = '';
        this.years = [];
        for (let i = (this.d.getFullYear() - 18); i > (this.d.getFullYear() - 100); i--) {
            this.years.push(i);
        }
    }
    userMale(flag) {
        if (flag) {
            this.sex = 0;
        } else {
            this.sex = 1;
        }
    }
    // dd/mm/yy
    userDate() {
        const temp: Date = new Date();
        this.birthday = this.day + '/' + this.month + '/' + this.year;
        this.age = temp.getFullYear() - this.year;
    }
    signUp() {
        if (this.email != null && this.firstname != null && this.password != null) {
            this.id++;
            const headers = new Headers({ 'Content-Type': 'application/json;charset=utf-8' });
            const userData = new User();
            this.userMale(this.sex_flag);
            this.userDate();
            userData.addUser(this.sex,
                this.email,
                this.firstname,
                this.lastname,
                /*this.birthday,*/
                this.weight,
                this.height,
                this.password,
                this.age);
            console.log(JSON.stringify(userData));
            this._httpService.post('http://localhost:57848/auth/register', JSON.stringify(userData), { headers: headers })
                .subscribe(
                () => { },
                err => console.error(err)
                );
            // this.addNewUser(this.id, userData);

            // this.router.navigate(['./login']);
        } else {
            alert('Error: Your data is empty');
        }
    }

    addNewUser(inc: number, data: any) {
        if (localStorage.getItem('user' + (inc).toString()) === null) {
            localStorage.setItem('user' + (inc).toString(), JSON.stringify(data));
        } else {
            inc++;
            this.addNewUser(inc, data);
        }
    }

}

class User {

    sex: any;
    age: number;
    email: string;
    firstname: string;
    lastname: string;
    //birthday: string;
    weight: number;
    height: number;
    password: string;
    id: number;

    constructor() {
        this.firstname = 'Noname';
        this.lastname = 'NoLastName';
        this.email = 'anonimus@gmail.com';
        //this.birthday = null;
        this.password = 'qwerty123';
    }

    addUser(_sex: any,
        _email: string,
        _firstname: string,
        _lastname: string,
        /* _birthday: string,*/
        _weight: number,
        _height: number,
        _password: string,
        _age: number) {

        this.sex = _sex;
        this.email = _email;
        this.firstname = _firstname;
        this.lastname = _lastname;
        //this.birthday = _birthday;
        this.weight = _weight;
        this.height = _height;
        this.password = _password;
        this.age = _age;
    }
    print() {
        console.log('Name : ' + this.firstname + '\n' +
            'Surname : ' + this.lastname + '\n' +
            'Email : ' + this.email + '\n' +
            /* 'Year of birth : ' + this.birthday + '\n' +*/
            'Name : ' + this.sex + '\n' +
            'Name : ' + this.weight + '\n' +
            'Name : ' + this.height + '\n' +
            'Password : ' + this.password);
    }
}

