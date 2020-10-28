import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";

import { appRoutes } from "src/routes";

import { AppComponent } from "./app.component";
import { NavBarComponent } from "./nav-bar/nav-bar.component";
import { EntriesComponent } from "./entries/entries.component";
import { EntryComponent } from "./entry/entry.component";

import { ImageService } from "./shared/ImageService/image.service";
import { DateService } from "./shared/DateService/date.service";

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    EntriesComponent,
    EntryComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appRoutes),
  ],
  providers: [ImageService, DateService],
  bootstrap: [AppComponent],
})
export class AppModule {}
