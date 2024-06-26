﻿using Microsoft.EntityFrameworkCore;
using NotificationService.Domain.Notification;
using NotificationService.Infrastructure.Base;
using NotificationService.Infrastructure.Context;
using NotificationService.Infrastructure.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Infrastructure.Repositories
{
    public class NotificationTemplateRepository : INotificationTemplateRepository
    {
        private readonly SqlContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public NotificationTemplateRepository(SqlContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<NotificationTemplate>> GetAll()
        {
            return await _context.NotificationTemplate.AsNoTracking().ToListAsync();
        }

        public async Task<NotificationTemplate> GetById(NotificationTemplateId id)
        {
            return await _context.NotificationTemplate.FindAsync(id);
        }


        public async Task<NotificationTemplate> GetByName(string notificationTemplateName)
        {
            var notificationTemplate = await _context.NotificationTemplate.FirstOrDefaultAsync(t => t.NotificationTemplateName.Trim() == notificationTemplateName.Trim());
            return notificationTemplate;
        }

        public async Task<NotificationTemplateId> Insert(NotificationTemplate notificationTemplate)
        {
            if (GetByName(notificationTemplate.NotificationTemplateName) == null)
                throw new DatabaseException("Duplicate Name...!");

            await _context.AddAsync(notificationTemplate);
            await _unitOfWork.SaveChanges();
            return notificationTemplate.Id;
        }

        public async Task Update(NotificationTemplate notificationTemplate)
        {
            var currentNotificationTemplate = await _context.NotificationTemplate.FindAsync(notificationTemplate.Id);

            if (currentNotificationTemplate == null)
                throw new Base.DatabaseException("NotificationTemplate Id in not valid");

            currentNotificationTemplate.Update(notificationTemplate);
            _unitOfWork.SaveChanges();
        }

        public async Task Delete(NotificationTemplateId id)
        {
            var notificationTemplate = NotificationTemplate.CreateNewForDelete(id);

            _context.Remove(notificationTemplate);
            await _unitOfWork.SaveChanges();
        }

    }
}
