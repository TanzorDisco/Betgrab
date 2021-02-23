import { Component, Input, OnDestroy, OnInit } from "@angular/core";

@Component({
    selector: 'app-sync-some',
    template: `<div>{{now}}</div>`
})
export class SomeSyncComponent implements OnInit, OnDestroy {

    @Input()
    now: Date = new Date();

    ngOnDestroy(): void {
    }
    ngOnInit(): void {
    }
}