import { Component, OnInit } from "@angular/core";
import { Entry } from "../models/Entry/entry.model";
import { ImageService } from "../shared/ImageService/image.service";
import { ActivatedRoute } from "@angular/router";
import { DateService } from "../shared/DateService/date.service";

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
