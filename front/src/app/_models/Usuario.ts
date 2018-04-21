export interface Self {
    href: string;
}

export interface Links {
    self: Self;
}

export interface Usuario{
    id: string;
    nome: string;
    username: string;
    _links: Links;
}