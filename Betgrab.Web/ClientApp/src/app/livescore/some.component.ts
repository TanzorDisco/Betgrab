import { Component, Input, OnDestroy, OnInit } from "@angular/core";
import { BehaviorSubject } from "rxjs";


@Component({
    selector: 'app-some',
    template: `<div>{{now | async}}</div>`
})
export class SomeComponent implements OnInit, OnDestroy {

    @Input()
    now: BehaviorSubject<Date> = new BehaviorSubject<Date>(new Date());

    ngOnDestroy(): void {
    }
    ngOnInit(): void {
    }
}