import { Component, OnInit } from '@angular/core';
import {Http, RequestOptions, RequestOptionsArgs, Headers} from '@angular/http'
import {Profile} from '../model/profile.component.model'

@Component({
  selector: 'profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

    public profile:Profile;

  constructor(private httpService:Http) { }

  ngOnInit() {
    const headers = new Headers({ 'Content-Type': 'application/json','Authorization':'Bearer '+localStorage.getItem('token') });

    let opts:RequestOptionsArgs = { headers: headers };
     this.httpService.get('http://localhost:57848/user/profile',opts).subscribe( (response) => 
     {
        this.profile = response.json();
     },
     (error) => 
     {
         console.log(error.json());
    });
  }
  change_profile()

  { const headers = new Headers({ 'Content-Type': 'application/json','Authorization':'Bearer '+localStorage.getItem('token') });
  
      let opts:RequestOptionsArgs = { headers: headers };
      console.log(this.profile);
      this.httpService.put('http://localhost:57848/user/profile',this.profile,opts).subscribe((response)=>console.log(response));
  }
}