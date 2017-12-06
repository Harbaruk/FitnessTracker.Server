import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Router } from '@angular/router';

import { Observable } from 'rxjs/Observable';
import * as $ from 'jquery';

@Injectable()
export class ApiService 
{
    private token:string = localStorage.getItem('token');

    private defaultOptions: {[key: string]: any} = {
        headers: {
            'Accept': '*/*'
        }
    };

    constructor(
        private http: Http,
        private router: Router)
        {  }

        post(
            url: string, 
            body: any, 
            options?: {[key: string]: any}
        ): Observable<any> {
            return this.request(
                url,
                $.extend(true, { method: 'POST', body: body }, this.defaultOptions, options)
            );
        }
    
        get(
            url: string, 
            options?: {[key: string]: any}
        ): Observable<any> {
            return this.request(
                url, 
                $.extend(true, { method: 'GET' }, this.defaultOptions, options)
            );
        }
    
        delete(
            url: string, 
            body?: any, 
            options?: {[key: string]: any}
        ): Observable<any> {
            return this.request(
                url, 
                $.extend(true, { method: 'DELETE', body: body }, this.defaultOptions, options)
            );
        }

        put(
            url: string, 
            body?: any, 
            options?: {[key: string]: any}
        ): Observable<any> {
            return this.request(
                url, 
                $.extend(true, { method: 'PUT', body: body }, this.defaultOptions, options)
            );
        }
    
        private request(
            url: string, 
            options: {[key: string]: any}
        ): Observable<any> {
    
            this.addToken(url, options);
    
            let observable = this.http.request('http://localhost:57848/' + url, options);

            return observable;
        }
    
        private addToken(url: string, options: {[key: string]: any}): void {
            let token = localStorage.getItem('token');
            if (token) {
                options['headers']['Authorization'] = `Bearer ${token}`;
            }
        }
    
}
