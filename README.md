# BigBallGame
## About
  Proiectul e realizat folosind Windows Forms App. Acesta este împarțit ăn mai multe clase. 
## Principalele clase 
### Ball
* Aici se stocheaza informațiile despre bilă cât și metodele pentru mișcarea și desenarea acesteia

### BallManager
* După cum îi spunen numele aici sunt stocate toate bilele create. Aici avem logica principala a jocului, Instanțierea bilelor fără a se suprapune și
actualizarea bilelor prin verificarea coliziuni cu alte bile și cu marginile ferestrei
(Se instanțiază 3 bile Regular manual pentru a ne asigura ca jocul e valid)

În loc de următorul cod :
```cs
while(!finished)
{
  Turn();
  Delay();
}
```
Am folosit un Timer
