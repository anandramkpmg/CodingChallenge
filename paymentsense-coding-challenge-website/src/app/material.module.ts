import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { 
    MatToolbarModule, 
    MatButtonModule, 
    MatSidenavModule, 
    MatIconModule, 
    MatListModule, 
    MatTableModule, 
    MatPaginatorModule, 
    MatSortModule,
    MatProgressBarModule,
    MatSelectModule,
    MatTabsModule,
    MatDividerModule,
    MatGridListModule, 
    MatCardModule, 
    MatMenuModule,
    MatInputModule
} from '@angular/material';

@NgModule({
    imports: [
        CommonModule
    ],
    exports: [
        MatToolbarModule, 
        MatButtonModule, 
        MatSidenavModule, 
        MatIconModule, 
        MatListModule, 
        MatTableModule, 
        MatPaginatorModule, 
        MatSortModule,
        MatProgressBarModule,
        MatSelectModule,
        MatTabsModule,
        MatDividerModule,
        MatGridListModule, 
        MatCardModule, 
        MatMenuModule,
        MatInputModule
    ]
})

export class MaterialModule {}