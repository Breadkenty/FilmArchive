import { Routes } from "@angular/router";
import { AboutComponent } from "./app/components/about/about.component";
import { EntriesComponent } from "./app/components/entries/entries.component";
import { EntryComponent } from "./app/components/entry/entry.component";
import { UploadComponent } from "./app/components/upload/upload.component";

export const appRoutes: Routes = [
  { path: "", component: EntriesComponent },
  { path: "about", component: AboutComponent },
  { path: "upload", component: UploadComponent },
  { path: "entry/:id", component: EntryComponent },
];
