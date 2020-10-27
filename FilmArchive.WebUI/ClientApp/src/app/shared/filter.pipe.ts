import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
  name: "imageFilter",
})
export class ImageFilterPipe implements PipeTransform {
  transform(items: any[], criteria: string): any {
    if (criteria === "all") {
      return items;
    } else {
      return items.filter((item) => {
        item.title.includes(criteria);
      });
    }
  }
}
