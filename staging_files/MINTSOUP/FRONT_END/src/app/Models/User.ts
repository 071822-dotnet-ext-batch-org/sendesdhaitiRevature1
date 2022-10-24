export interface Viewer{
    ID? : string,
    Auth0ID? : string,
    Fn? : string,
    Ln? : string,
    Email? : string,
    Image? : string,
    Username? : string,
    AboutMe? : string,
    StreetAddy? : string,
    City? : string,
    State? : string,
    Country? : string,
    AreaCode? : string,
    Role? : number,
    MembershipStatus? : number,
    DateSignedUp? : Date,
    LastSignedIn? : Date
}
export interface LoginDTO{
    email? : string,
    auth0ID? : string
}