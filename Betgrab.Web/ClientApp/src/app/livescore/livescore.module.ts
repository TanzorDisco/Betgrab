import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { A11yModule } from '@angular/cdk/a11y';
import { LivescoreIndexComponent } from "./index/livescore-index.component";
import { LivescoreItemComponent } from './livescore-event/livescore-event.component';
import { MaterialModule } from "../material.module";
import { SomeComponent } from "./some.component";
import { SomeSyncComponent } from "./some-sync.componen";


@NgModule({
    declarations: [
        LivescoreIndexComponent,
        LivescoreItemComponent,
        SomeComponent,
        SomeSyncComponent
    ],
    imports:[
        CommonModule,
        BrowserModule,
        BrowserAnimationsModule,
        MaterialModule,
        FormsModule,
        A11yModule,
        RouterModule.forRoot([
            { path: 'livescore', component: LivescoreIndexComponent }
        ]),
    ]
})
export class LivescoreModule { }