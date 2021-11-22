import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ContaService } from '@app/Services/conta/conta.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  isCollapsed = true;

  constructor(public contaService: ContaService,
              private router: Router) { }

  ngOnInit() {
  }

  logout(): void {
    this.contaService.logout();
    this.router.navigateByUrl('/home');
  }

  disableMenu(): boolean {
    return (this.router.url == '/usuario/login'
      || this.router.url == '/home'
      ? true
      : false);
  }

}
