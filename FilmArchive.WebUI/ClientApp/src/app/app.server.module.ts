import { NgModule } from "@angular/core";
import { ServerModule } from "@angular/platform-server";
import { ModuleMapLoaderModule } from "@nguniversal/module-map-ngfactory-loader";
import { AppComponent } from "./app.component";
import { AppModule } from "./app.module";
import { HttpClientModule } from "@angular/common/http";
import { DataService } from "./data.service";

@NgModule({
  imports: [AppModule, ServerModule, ModuleMapLoaderModule, HttpClientModule],
  providers: [DataService],
  bootstrap: [AppComponent],
})
export class AppServerModule {}
