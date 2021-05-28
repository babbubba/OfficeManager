# OfficeManager
Applicazione multilayer (Data Layer, Business Logic e Presentation Layer ma tutto nello stesso progetto per praticità) a scopo didattico.
Si tratta di una applicazione Web API realizzanda usando alcuni design pattern tra i più comuni con lo scopo di rappresentare un ufficio composto di stanze e persone in relazione tra di loro.
I patter utilizzati sono:
- Data Mapper
- Repository
- Service
- Dependency Injection

Questo progetto didattico si pone l'obiettivo di mostrare come disegnare e sviluppare una solida applicazione basandosi sul principio SRP (Single Responsibility Principle)...
che per come lo interpreto io in parole povere vuol dire fai le cose come se possano sempre cambiare e chiunque possa farlo e soprattuto non scrivere due volte lo stesso codice per due operazioni differenti.

L'applicazione usa l'ORM nhibernate per la persistenza dei dati. Questo rappresenta una contraddizione perchè spesso un ORM viene definito un anti Pattern... ma bisogna accettare qualche compromesso nella programmazione, soprattutto quando vogliamo che la nostra applicazione sia installabile su diversi sistemi ed utilizzi diversi database.
PEr praticità la configurazione dell'ORM e la gestione delle sessioni è demandata al pacchetto bs.Data (che trovate tra i miei repositories su GitHub) che rende molto più semplice l'utilizzo di nHibernate.
