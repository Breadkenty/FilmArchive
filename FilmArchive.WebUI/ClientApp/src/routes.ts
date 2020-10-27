import { Routes } from "@angular/router";
import { EntriesComponent } from "./app/entries/entries.component";
import { EntryComponent } from "./app/entry/entry.component";

export const appRoutes: Routes = [
  { path: "entries", component: EntriesComponent },
  { path: "entry/:id", component: EntryComponent },
  { path: "", redirectTo: "/entries", pathMatch: "full" },
];
