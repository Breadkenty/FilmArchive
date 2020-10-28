import { Routes } from "@angular/router";
import { EntriesComponent } from "./app/components/entries/entries.component";
import { EntryComponent } from "./app/components/entry/entry.component";

export const appRoutes: Routes = [
  { path: "", component: EntriesComponent },
  { path: "entry/:id", component: EntryComponent },
  { path: "", redirectTo: "/entries", pathMatch: "full" },
];
