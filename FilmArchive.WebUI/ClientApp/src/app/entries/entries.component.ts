import { Component, Input, OnChanges, SimpleChanges } from "@angular/core";
import { Entry } from "../entry.model";
import { ImageService } from "../shared/image.service";

@Component({
  selector: "app-entries",
  templateUrl: "./entries.component.html",
  styleUrls: ["./entries.component.less"],
})
export class EntriesComponent implements OnChanges {
  @Input() filterBy?: string = "all";
  entries$: Entry[];

  constructor(private imageService: ImageService) {
    this.imageService.getEntries().subscribe((data) => (this.entries$ = data));
  }

  ngOnChanges() {
    this.imageService.getEntries().subscribe((data) => (this.entries$ = data));
  }
}
