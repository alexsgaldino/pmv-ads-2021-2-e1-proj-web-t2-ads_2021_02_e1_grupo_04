/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { UnidadeMedidaComponent } from './UnidadeMedida.component';

describe('UnidadeMedidaComponent', () => {
  let component: UnidadeMedidaComponent;
  let fixture: ComponentFixture<UnidadeMedidaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UnidadeMedidaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UnidadeMedidaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
