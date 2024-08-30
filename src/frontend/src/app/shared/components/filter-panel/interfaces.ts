import { FormControl } from "@angular/forms";
import { ICRUDService } from "../../services/crud.service";
import { Observable } from "rxjs";

export interface IFilterPanelProps<T extends {id: string, name:string}> {
    id: string,
    dataService: ICRUDService<T>,
    filterCallbackFn: (filterMap: Map<string, string | null>) => void,
    cancelCallback: () => void,
    style?: Object
    label?: string
    title?: string
    handleFormControls?: (fields: T[]) => Map<string, FormControl>
}