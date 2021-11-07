import { ComponentFixture, TestBed } from '@angular/core/testing';
import { UsuarioPerfilComponent } from 'src/app/components/usuario/usuarioPerfil/usuarioPerfil.component';

describe('UsuarioPerfilComponent', () => {
  let component: UsuarioPerfilComponent;
  let fixture: ComponentFixture<UsuarioPerfilComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UsuarioPerfilComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UsuarioPerfilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
