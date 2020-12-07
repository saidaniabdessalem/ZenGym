import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-team',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.css']
})
export class TeamComponent implements OnInit {

  teams: any;
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getTeams();
  }

  getTeams(): void {
    this.http.get('http://localhost:5000/api/team').subscribe(response => {
      this.teams = response;
    }, error => {
      console.log(error);
    });
  }

}
