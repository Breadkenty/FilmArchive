import { Component, OnInit } from "@angular/core";
import { Entry } from "../entry.model";
import { ImageService } from "../shared/image.service";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-entry",
  templateUrl: "./entry.component.html",
  styleUrls: ["./entry.component.less"],
})
export class EntryComponent implements OnInit {
  entry$: Entry;

  constructor(
    private imageServive: ImageService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.imageServive.getEntry(+this.route.snapshot.params["id"]);
  }
}
