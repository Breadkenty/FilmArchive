import { Component, OnInit } from "@angular/core";
import * as moment from "moment";
import { Entry } from "./models/Entry/entry.model";
import { ImageService } from "./shared/ImageService/image.service";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
})
export class AppComponent implements OnInit {
  entries$: Entry[];
  entry$: Entry;

  constructor(private imageService: ImageService) {}

  ngOnInit() {}
}
