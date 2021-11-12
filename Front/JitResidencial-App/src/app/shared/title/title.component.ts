import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-title',
  templateUrl: './title.component.html',
  styleUrls: ['./title.component.scss']
})
export class TitleComponent implements OnInit {
  @Input() title = "Padrão";
  @Input() iconClass = "fa fa-store";
  @Input() subtitle = "by PUC-MINAS EAD";
  @Input() buttonListing = false;
  @Input() action = "Cadastro"


  constructor(private router: Router) { }

  ngOnInit() {}
    listar(): void{
      console.log("aqui",[`/${this.title.toLocaleLowerCase()}/list`]);
    this.router.navigate([`/${this.title.toLocaleLowerCase()}/list`]);
  }
}
