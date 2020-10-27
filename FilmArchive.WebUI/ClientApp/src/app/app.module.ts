import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";

import { AppComponent } from "./app.component";
import { NavBarComponent } from "./nav-bar/nav-bar.component";
import { EntriesComponent } from "./entries/entries.component";
import { ImageService } from "./shared/image.service";
import { ImageFilterPipe } from "./shared/filter.pipe";
import { EntryComponent } from "./entry/entry.component";
import { appRoutes } from "src/routes";

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    EntriesComponent,
    ImageFilterPipe,
    EntryComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appRoutes),
  ],
  providers: [ImageService, ImageFilterPipe],
  bootstrap: [AppComponent],
})
export class AppModule {}
