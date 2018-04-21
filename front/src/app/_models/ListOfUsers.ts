export interface Self {
    href: string;
}

export interface Next {
    href: string;
}

export interface Links {
    self: Self;
    next: Next;
}

export interface Usuario {
    id: string;
    nome: string;
    username: string;
    _links: any;
}

export interface Embedded {
    usuarios: Array<Usuario>;
}

export interface ListOfUsers {
    total: number;
    perPage: number;
    _links: Links;
    _embedded: Embedded;
}

