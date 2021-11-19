import { Component, OnInit } from '@angular/core';
import { cwd } from 'process';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {}
  loggedIn: boolean;
  
  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
  }

  login() {
    this.accountService.login(this.model).subscribe(Response => {
      console.log(Response);
      this.loggedIn = true;
    }, 
    
    )
  }

}
