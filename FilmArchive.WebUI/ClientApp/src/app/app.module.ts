import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";

import { appRoutes } from "src/routes";

import { AppComponent } from "./app.component";
import { NavBarComponent } from "./components/nav-bar/nav-bar.component";
import { EntriesComponent } from "./components/entries/entries.component";
import { EntryComponent } from "./components/entry/entry.component";

import { ImageService } from "./shared/ImageService/image.service";
import { DateService } from "./shared/DateService/date.service";
import { AboutComponent } from "./components/about/about.component";
import { FooterComponent } from './components/footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    EntriesComponent,
    EntryComponent,
    AboutComponent,
    FooterComponent,
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
