import { Component } from "@angular/core";
import { SearchResult } from "src/models/searh-result";
import { SearchService } from "src/services/search.service";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
})
export class AppComponent {
  textToSearch: string = "";
  dynamicSearchResult: any[] = [];

  constructor(private searchService: SearchService) {}

  onSearchClick() {
    this.searchService.search(this.textToSearch).subscribe((result) => {
      debugger;
      this.bindDynamicSearchResult(result);
    });
  }

  clear(): void {
    this.textToSearch = "";
    this.dynamicSearchResult = [];
  }

  bindDynamicSearchResult(searchResult: SearchResult) {
    this.dynamicSearchResult = [];

    searchResult.orderedModelIds.forEach((orderedId) => {
      var group = searchResult.groups.find((x) => x.id === orderedId);

      if (group) {
        this.dynamicSearchResult.push(group);
      }

      var media = searchResult.medias.find((x) => x.id === orderedId);

      if (media) {
        this.dynamicSearchResult.push(media);
      }

      var building = searchResult.locks.find((x) => x.id === orderedId);

      if (building) {
        this.dynamicSearchResult.push(building);
      }

      var lock = searchResult.buildings.find((x) => x.id === orderedId);

      if (lock) {
        this.dynamicSearchResult.push(lock);
      }
    });
  }
}
