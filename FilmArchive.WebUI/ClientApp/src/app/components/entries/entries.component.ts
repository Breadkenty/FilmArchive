import { Component, OnInit } from "@angular/core";
import { Entry } from "../../models/Entry/entry.model";
import { DateService } from "../../shared/DateService/date.service";
import { ImageService } from "../../shared/ImageService/image.service";

@Component({
  selector: "app-entries",
  templateUrl: "./entries.component.html",
  styleUrls: ["./entries.component.less"],
})
export class EntriesComponent implements OnInit {
  entries$: Entry[];
  dateService$;

  constructor(
    private imageService: ImageService,
    private dateService: DateService
  ) {}

  ngOnInit() {
    this.dateService$ = this.dateService;
    this.imageService.getEntries().subscribe((data) => (this.entries$ = data));
  }
}
