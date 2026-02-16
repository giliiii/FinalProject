import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RandManage } from './rand-manage';

describe('RandManage', () => {
  let component: RandManage;
  let fixture: ComponentFixture<RandManage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RandManage]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RandManage);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
