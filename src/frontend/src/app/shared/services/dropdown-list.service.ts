import { BehaviorSubject } from "rxjs";

export interface IDropdownListService<T extends {id: string, name: string}> {
    readonly selectedItem$: BehaviorSubject<T>
    updateItem(item: T): void
}

export class DropdownListService<T extends {id: string, name: string}> implements IDropdownListService<T> {
    selectedItem$: BehaviorSubject<T>
    constructor(beginItem: T) {
        this.selectedItem$ = new BehaviorSubject<T>(beginItem);
        
    }
    updateItem(item: T): void {
        this.selectedItem$.next(item)        
    }
    
}