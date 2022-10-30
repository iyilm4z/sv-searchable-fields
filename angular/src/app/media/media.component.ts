import { ChangeDetectionStrategy, Component, Input } from "@angular/core";
import { MediaModel } from "src/models/media-model";

@Component({
  selector: "app-media",
  templateUrl: "./media.component.html",
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class MediaComponent {
  @Input() model: MediaModel | undefined;
}
