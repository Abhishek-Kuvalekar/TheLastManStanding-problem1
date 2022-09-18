import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { convertToCamelCase } from 'src/common/utility-functions';
import { NavBarItem } from './model';
import { routes } from './routes';

@Component({
    selector: 'nav-bar',
    templateUrl: './nav-bar.component.html',
    styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
    isNavbarCollapsed = true;
    navBarItems: NavBarItem[] = [];
    
    constructor(
        private router: Router
    ) { }
    
    ngOnInit(): void {
        this.configureNavBar();
    }

    activateRoute(url: string) {
        this.router.navigateByUrl(url)
    }

    isNavBarItemActive(navBarItem: NavBarItem) {
        return this.router.isActive(navBarItem.Route, true);
    }

    private configureNavBar() {
        this.navBarItems = [];
        for (const route of routes) {
            this.navBarItems.push({
                Route: `/${route.path}`,
                Name: this.getNameFromPath(route.path),
                Component: route.component
            })
        }
    }

    private getNameFromPath(path: string | undefined): string {
        if (!path) {
            return '';
        }

        const parts: string[] = [];
        for (const part of path.split('-')) {
            parts.push(convertToCamelCase(part));
        }
        return parts.join(' ');
    }
}