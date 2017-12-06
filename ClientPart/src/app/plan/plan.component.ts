import { Component, OnInit } from '@angular/core';
import {Http, RequestOptions, RequestOptionsArgs, Headers} from '@angular/http'
import { Plan } from '../model/plan.component.model';
import { Observable } from 'rxjs/Observable';
import {ApiService } from '../services/api.service'

@Component({
  selector: 'app-plan',
  templateUrl: './plan.component.html',
  styleUrls: ['./plan.component.css']
})
export class PlanComponent implements OnInit {

  public plan:Plan[];

  constructor(private httpService:Http, private apiService:ApiService) { }

  ngOnInit() {

    const headers = new Headers({ 'Content-Type': 'application/json','Authorization':'Bearer '+localStorage.getItem('token') });
    
        let opts:RequestOptionsArgs = { headers: headers };
         this.httpService.get('http://localhost:57848/user/plans',opts).subscribe( (response) => 
         {
            this.plan = response.json();
         },
         (error) => 
         {
             console.log(error.json());
        });
  }

}
