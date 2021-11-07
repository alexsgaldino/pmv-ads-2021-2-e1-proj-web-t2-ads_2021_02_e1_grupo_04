import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ListaPrecoComponent } from 'src/app/components/listaPreco/listaPreco.component';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.scss']
})
export class TituloComponent implements OnInit {
  @Input() titulo = "Padrão";
  @Input() iconClass = "fa fa-store";
  @Input() subtitulo = "by PUC-MINAS EAD";
  @Input() botaoListar = false;
  @Input() acao = "Cadastro"


  constructor(private router: Router) { }

  ngOnInit() {}
    listar(): void{
      console.log([`/${this.titulo.toLocaleLowerCase()}/lista`]);
    this.router.navigate([`/${this.titulo.toLocaleLowerCase()}/lista`]);
  }
}
