import { Component, OnInit } from "@angular/core";
import { Data } from "@angular/router";
import { DataService } from "./data.service";
import { Entry } from "./entry.model";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
})
export class AppComponent implements OnInit {
  entries$: Entry[];

  constructor(private dataService: DataService) {}

  ngOnInit() {
    return this.dataService
      .getEntries()
      .subscribe((data) => (this.entries$ = data));
  }
}
