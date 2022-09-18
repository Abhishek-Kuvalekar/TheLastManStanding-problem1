export function convertToCamelCase(str: string): string {
    if (!str) {
        return str;
    }

    if (str.length === 1) {
        return str.toUpperCase();
    }

    return str.substring(0, 1).toUpperCase() + str.substring(1).toLowerCase();
}

export function distinct(items: any[]): any[] {
    if (!items) {
        return items;
    }

    return items.filter((v, i, a) => a.indexOf(v) === i);
}