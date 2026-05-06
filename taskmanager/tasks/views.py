from django.shortcuts import render, redirect
from .models import Task
from .forms import TaskForm
from django.contrib.auth.decorators import login_required

@login_required
def task_list(request):

    tasks = Task.objects.all()

    status = request.GET.get('status')

    if status:
        tasks = tasks.filter(status=status)


    context = {
        'tasks': tasks
    }

    return render(request, 'tasks/task_list.html', context)

@login_required
def add_task(request):

    if request.method == 'POST':
        form = TaskForm(request.POST)

        if form.is_valid():
            task = form.save(commit=False)
            task.owner = request.user
            task.save()

            return redirect('task_list')

    else:
        form = TaskForm()

    context = {
        'form': form
    }

    return render(request, 'tasks/add_task.html', context)
