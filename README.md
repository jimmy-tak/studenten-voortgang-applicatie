# studenten-voortgang-applicatie

A toy project to learn C#

## Architectuur
Ik heb geprobeerd de applicatie te bouwen volgens het Model - View - Controller design pattern.

## Model
Het model ziet er in grote lijnen als volgt uit:

![Klasse diagram](https://github.com/jimmy-tak/studenten-voortgang-applicatie/blob/master/class_diagram.png)

## View
Voor de meeste klassen in het model is een view gebouwd die de informatie in die klasse kan weergeven en ook informatie kan opvragen van de gebruiker. Alle views erven van `BaseView` die methodes bevat die door alle views gebruikt worden. Een aantal van deze methoden worden ook door de controllers aangeroepen en hadden achteraf beter static kunnen zijn.

## Controller
De controllers bevatten de meeste logica van de applicatie.

- `LoginController` 
- `MenuController`
Het model voor het menu bestaat uit een `Menu` en `MenuItem` klasse. Een `MenuItem` kan verwijzen naar een ander (sub)`Menu` of een callback naar een methode in een van de controllers. Dit is geimplementeerd met delegates. Er wordt ook in een `Stack` bijgehouden welke menu's de gebruiker heeft bezocht om op de juiste wijze weer terug te navigeren door de menu's. 
- `SchoolController`
De methodes in deze klasse komt grotendeels overeen met de requirements van de opdracht. Student toevoegen, wijzigen, verwijderen, enz., enz. Het maakt gebruik van views om gegevens weer te geven en op te vragen van de gebruiker en wijzigd het model ahv. de door de gebruiker opgevoerde gegevens.
- `StudentCourseController`
Analoog aan `SchoolController`, maar dan voor functionaliteit die alleen beschikbaar is voor studenten.
- `TeacherCourseController` 
- Analoog aan `SchoolController`, maar dan voor functionaliteit die alleen beschikbaar is voor docenten.
- `FileController` Niet uitgewerkt ivm. gebrek aan tijd.
