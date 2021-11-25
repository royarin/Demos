- Install dapr cli. See https://dapr.io
    Install the "slim" installation without the default components. We will deploy any dependencies using tye.

- Install tye - https://github.com/dotnet/tye
- Start Docker Desktop
- From the folder that contains your tye.yml file, execute
    ```
    tye run
    ```

- tye dashboard available at http://localhost:8000 unless port 800 is already in use


