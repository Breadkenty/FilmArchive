import { Component, OnChanges } from "@angular/core";
import { Entry } from "../entry.model";
import { ImageService } from "./shared/image.service";

@Component({
  selector: "app-entries",
  templateUrl: "./entries.component.html",
  styleUrls: ["./entries.component.less"],
})
export class EntriesComponent {
  entries$: Entry[];

  constructor(private imageService: ImageService) {
    // this.entries$ = imageService.getEntries().subscribe((data) => (this.entries$ = data));
  }
}
