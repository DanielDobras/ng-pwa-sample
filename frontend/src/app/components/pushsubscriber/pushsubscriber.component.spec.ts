import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { PushsubscriberComponent } from "./pushsubscriber.component";

describe("PushsubscriberComponent", () => {
  let component: PushsubscriberComponent;
  let fixture: ComponentFixture<PushsubscriberComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PushsubscriberComponent]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PushsubscriberComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
