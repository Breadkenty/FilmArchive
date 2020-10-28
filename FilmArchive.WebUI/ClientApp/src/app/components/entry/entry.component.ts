import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";

import { Entry } from "src/app/models/Entry/entry.model";

import { DateService } from "src/app/shared/DateService/date.service";
import { ImageService } from "src/app/shared/ImageService/image.service";

@Component({
  selector: "app-entry",
  templateUrl: "./entry.component.html",
  styleUrls: ["./entry.component.less"],
})
export class EntryComponent implements OnInit {
  entry$: Entry;
  dateService$;

  constructor(
    private imageService: ImageService,
    private route: ActivatedRoute,
    private dateService: DateService
  ) {}

  ngOnInit() {
    this.dateService$ = this.dateService;
    this.imageService
      .getEntry(this.route.snapshot.params["id"])
      .subscribe((data) => (this.entry$ = data));
  }
}
