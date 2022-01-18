export class Knjiga{

    constructor(sifra, naziv, zanr, biblioteka){
        this.sifra=sifra;
        this.naziv=naziv;
        this.zanr=zanr;
        this.biblioteka=biblioteka;
    }

    crtaj(host){
       
        var tr = document.createElement("tr");
        host.appendChild(tr);

        var el = document.createElement("td");
        el.innerHTML=this.sifra;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML=this.naziv;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML=this.zanr;
        tr.appendChild(el);

        el = document.createElement("td");
        el.innerHTML=this.biblioteka;
        tr.appendChild(el);


        /*el = document.createElement("td");
        tr.appendChild(el);
        let dugme = document.createElement("button");
        dugme.innerHTML="Obrisi";
        el.appendChild(dugme);
        dugme.onclick=(ev)=>this.obrisiZapisOPolozenomIspitu();*/
    }
    obrisiZapisOPolozenomIspitu(){
        //sami implementirate
        //ispravite priavljanje podataka o polozenim ispitima tako da vraca i id iz tabele studentPredmet
        //upamtite ga kao parametar ove klase
        //fetch za metodu za brisanje
        //ukoliko sve prodje ok, u then delu ukoloniti red iz prikaza
    }
    
}