import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from "./app.component";
import { SearchService } from "./../services/search.service";
import { FormsModule } from "@angular/forms";
import { BuildingComponent } from "./building/building.component";
import { GroupComponent } from "./group/group.component";
import { LockComponent } from "./lock/lock.component";
import { MediaComponent } from "./media/media.component";

@NgModule({
  declarations: [
    AppComponent,
    BuildingComponent,
    GroupComponent,
    LockComponent,
    MediaComponent,
  ],
  imports: [BrowserModule, HttpClientModule, FormsModule],
  providers: [SearchService],
  bootstrap: [AppComponent],
})
export class AppModule {}
