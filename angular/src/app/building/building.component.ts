import { ChangeDetectionStrategy, Component, Input } from "@angular/core";
import { BuildingModel } from "src/models/building-model";

@Component({
  selector: "app-building",
  templateUrl: "./building.component.html",
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class BuildingComponent {
  @Input() model: BuildingModel | undefined;
}
