import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { UsuarioListaComponent } from './usuarioLista.component';


describe('UsuarioListaComponent', () => {
  let component: UsuarioListaComponent;
  let fixture: ComponentFixture<UsuarioListaComponent>;

  beforeEach(async (() => {
    TestBed.configureTestingModule({
      declarations: [ UsuarioListaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UsuarioListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
