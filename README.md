# ProgressBar
This is a simple implementation of progress bar in C# Console Application.

## Usage
**Percentage mode**
```
ProgressBar progressBar = new ProgressBar();
progressBar.Show();
progressBar.Update(0.01);
```
**Item count mode**
```
ProgressBar progressBar = new ProgressBar(100);
progressBar.Show();
progressBar.Update(1);
```

## Example

![ProgressBar](https://user-images.githubusercontent.com/7996256/110447591-59ff9200-80fb-11eb-89a3-998c1c4c7974.gif)
