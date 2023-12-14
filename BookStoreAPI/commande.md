## commande utiles

### Creation de BDD

```bash
sqlite3 bookStore.db "VACUUM;"

```
### Migration

```bash 
dotnet ef migrations add InitialCreate --context ApplicationDbContext
```
```bash
dotnet ef migrations add InitialCreate --context UserDbContext
```

### Update
    
```bash 
dotnet ef database update --context ApplicationDbContext
```
```bash
dotnet ef database update --context UserDbContext
```

